using Microsoft.AspNetCore.Components.Forms;
using StitchMaster.BusinessLogic;
using StitchMaster.DataLayer;

namespace StitchMaster.Components.Pages
{
    public partial class My_Gigs_Create_Gig
    {
        private string title;
        private string description;
        private Category category;
        private int price = 10;
        private int deliveryDays = 1;
        private string savedImagePath = null;
        private string imagePreviewUrl = null;

        private List<Category> categories = CategoryData.Instance.GetAllCategories();
        private TailorGig gig = new TailorGig(null, "descrption", new Category(1, "ctrio","male"), 1, 1, null);

        private IBrowserFile selectedFile;
        int SelectedCategoryId;

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

                // Generate a unique file name to avoid conflicts
                var uniqueFileName = $"{Guid.NewGuid()}_{selectedFile.Name}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Save the file to wwwroot/uploads/
                using var stream = selectedFile.OpenReadStream(maxAllowedSize: 5 * 1024 * 1024); // 5MB max
                using var fileStream = File.Create(filePath);
                await stream.CopyToAsync(fileStream);

                // Generate relative URL for image display
                savedImagePath = $"/uploads/{uniqueFileName}";
                imagePreviewUrl = savedImagePath;
            }
        }

        private void Cancel()
        {
            Navigation.NavigateTo("/my-gigs");
        }
        private async Task HandleSubmit()
        {
            // await _productService.AddProductAsync(Product);
            Navigation.NavigateTo("/my-gigs");
        }
        void IncrementDeliveryDays()
        {
            deliveryDays++;
        }

        void DecrementDeliveryDays()
        {
            if (deliveryDays > 1)
                deliveryDays--;
        }
    }
}
