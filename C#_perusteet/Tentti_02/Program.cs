using System;

namespace Tentti_02
{
    class Program
    {
        static void Main()
        {
            //Ohjelman ajo vikasietoisena
            try
            {
                Application.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
