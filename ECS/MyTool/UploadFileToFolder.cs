namespace ECS.Tool
{
    public static class UploadFileToFolder
    {
        public static string Upload(IFormFile file, string folderName)
        {
            try
            {
                var fileName = $"{DateTime.Now.Ticks}_{file.FileName}";
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", folderName, fileName);
                using (var myFile = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(myFile);
                }
                return fileName;
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}
