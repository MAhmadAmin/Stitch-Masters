using Microsoft.AspNetCore.Components.Forms;
using StitchMaster.BusinessLogic;
using StitchMaster.DataLayer;


namespace StitchMaster.Components.Pages
{
    public partial class My_Gigs_Create_Gig
    {
        private List<Category> categories = CategoryData.Instance.GetAllCategories();
        private TailorGig gigModel = new TailorGig() { GigDeliveryDays = 1, GigPrice = 10 };
        private bool success = false;
        private bool isSubmitting = false;

        private IBrowserFile selectedFile;
        int SelectedCategoryId;
        private async void HandleSubmit()
        {

            if (!string.IsNullOrEmpty(gigModel.GigTitle) && !string.IsNullOrEmpty(gigModel.GigDescription) && !string.IsNullOrEmpty(gigModel.ImageURL) && gigModel.GigPrice > 5 && SelectedCategoryId > 0)
            {
                if (isSubmitting)
                    return;
                isSubmitting = true;


                Tailor tailor = TailorData.Instance.GetTailorByEmail(UserState.Email);
                Category category = CategoryData.Instance.GetCategoryByID(SelectedCategoryId);

                TailorGig gig = new TailorGig(tailor, gigModel.GigTitle, gigModel.GigDescription, category, gigModel.GigPrice, gigModel.GigDeliveryDays, gigModel.ImageURL);

                int result = TailorGigData.Instance.StoreGig(gig);

                if(result == 1)
                {
                    await Task.Delay(2000);
                    Navigation.NavigateTo("/my-gigs");
                }

                isSubmitting = false;
            }
        }

        private void Cancel()
        {
            Navigation.NavigateTo("/my-gigs");
        }
        void IncrementDeliveryDays()
        {
            gigModel.GigDeliveryDays++;
        }

        void DecrementDeliveryDays()
        {
            if (gigModel.GigDeliveryDays > 1)
                gigModel.GigDeliveryDays--;
        }

        private async Task OnImageSelected(InputFileChangeEventArgs e)
        {

            if (e is null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            selectedFile = e.File;

            if (selectedFile != null)
            {
                // Define a folder inside wwwroot (e.g., "uploads")
                var uploadsFolder = Path.Combine(Environment.CurrentDirectory, "wwwroot", "uploads");

                // Create the folder if it doesn't exist
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var random = new Random();
                var shortRandom = random.Next(10000, 99999); // 5-digit random number
                var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss"); // Compact timestamp
                var extension = Path.GetExtension(selectedFile.Name); // Keep the original file extension
                var uniqueFileName = $"{timestamp}_{shortRandom}{extension}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);


                // Save the file to wwwroot/uploads/
                using var stream = selectedFile.OpenReadStream(maxAllowedSize: 5 * 1024 * 1024); // 5MB max
                using var fileStream = File.Create(filePath);
                await stream.CopyToAsync(fileStream);

                // Generate relative URL for image display
                gigModel.ImageURL = $"/uploads/{uniqueFileName}";
            }
        }
    }
}
