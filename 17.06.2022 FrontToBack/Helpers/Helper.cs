namespace _17._06._2022_FrontToBack.Helpers
{
    public class Helper
    {

        public static void DeleteImage (string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }

        public enum UserRoles
        {
            Member
        }
    }
}
