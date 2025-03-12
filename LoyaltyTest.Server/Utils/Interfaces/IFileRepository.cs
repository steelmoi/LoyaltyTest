namespace LoyaltyTest.Server.Utils.Interfaces
{
    public interface IFileRepository
    {
        Task<string> UploadFile(IFormFile file);
        IResult DownloadImage(string filePathImage);
    }
}
