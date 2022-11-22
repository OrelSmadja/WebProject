using System.ComponentModel.DataAnnotations;

namespace WebProject.Services
{
    public static class ExtensionValid
    {
        /// <summary>
        /// The allowed extensions that recieved from the model.
        /// </summary>


        public static bool IsValid(string? value)
        {
            string[] extensions = new string[] { "jpeg", "png", "jfif", "jpg" };
             
            if (value is not null)
            {
                int dotIndex = value.LastIndexOf('.');
                string pathExtension = value[(dotIndex + 1)..].ToLower();
                if (extensions.Contains(pathExtension))
                    return true;
            }
            return false;
        }
    }
}
