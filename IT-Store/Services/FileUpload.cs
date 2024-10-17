namespace IT_Store.Services
{
    public static class FileUpload
    {
        public static string SaveImage(IFormFile file)
        {
            if (file == null || file.Length <= 0)
                throw new ArgumentNullException(nameof(file));

            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uploads", "Images");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string fileName= GenerateFileName(file);
            string filePath = Path.Combine(folderPath, fileName);

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fs);
            }

            return Path.Combine("Uploads","Images", fileName);
        }
        private static string GenerateFileName(IFormFile file)
        {
            return DateTime.Now.ToString("yyyyMMddhhmmss") + "-" + new Random().Next() + "." + file.FileName.Split('.').Last();
        }
    }
}
