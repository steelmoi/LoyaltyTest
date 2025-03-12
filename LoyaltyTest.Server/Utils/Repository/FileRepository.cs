using LoyaltyTest.Server.Utils.Interfaces;

namespace LoyaltyTest.Server.Utils.Repository
{
    public class FileRepository: IFileRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileRepository(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            var fName = Guid.NewGuid().ToString();            
            var mimeType = Path.GetExtension(file.FileName);
            string FileName = $"Upload/{fName}{mimeType}";


            string filePath = Path.Combine(contentRootPath, FileName);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return FileName.Replace("Upload/", "");
        }

        public IResult DownloadImage(string filePathImage)
        {
            string contentRootPath = _webHostEnvironment.ContentRootPath;

            //var filePath = Path.Combine("Uploads", filePathImage);

            string filePath2Read = Path.Combine(contentRootPath, "Upload/"+filePathImage);

            var fileBytes = File.ReadAllBytes(filePath2Read);
            return Results.File(fileBytes, "application/octet-stream", filePathImage.Replace("Upload/", ""));
        }
    }
}
