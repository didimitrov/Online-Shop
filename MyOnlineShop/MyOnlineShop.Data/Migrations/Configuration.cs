using System.Collections.Generic;
using MyOnlineShop.Models;

namespace MyOnlineShop.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyOnlineShop.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MyOnlineShop.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //


            //var categories = new List<Category>
            //{
            //    new Category
            //    {
            //        Id = 1,
            //        Name = "Games",
            //        Description = "Best games",
            //        CategoryImgUrl =
            //            "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTMuJH0XsHnRCn7S5yc22cglgA_ZG8zGtxVzycOtsrNNuf4st9b"
            //    },
            //    new Category
            //    {
            //        Id = 2,
            //        Name = "IT",
            //        Description = "Sick IT",
            //        CategoryImgUrl =
            //            "data:image/jpeg;base64,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"
            //    },
            //    new Category
            //    {
            //        Id = 3,
            //        Name = "Bio",
            //        Description = "Bio prod",
            //        CategoryImgUrl =
            //            "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQa-N_d_73SOH7eJK-MfFfL1f1FBLy_7sro3PVbAF9CIy_MAjNq"
            //    }
            //};
            //categories.ForEach(x => context.Categories.AddOrUpdate(x));
            //context.SaveChanges();

            //var products = new List<Product>
            //{
            //    new Product
            //    {
            //        Id = 1,
            //        Title = "QL",
            //        CategoryId = 1,
            //        ProductArtUrl =
            //            "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcRhOx5zA1OH0UHWx8M0clVeX1RvQtlhw4yhW45Isrvm4SHgpNkBBA",
            //        Price = 49
            //    },
            //    new Product
            //    {
            //        Id = 2,
            //        Title = "C# 6.0",
            //        CategoryId = 2,
            //        ProductArtUrl =
            //            "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBxQTDBQUDxQUFRQUFBQUFBQUFRQYFBoUFRQWGBQUFBUYKCggGhwlHBcUITEkKCk3Li4uGB8zODM4NygtMysBCgoKDg0OGxAQGjccIBwtNTUsLC8zMCwvLDc0NDc3KywsNzcrLC43LCw1LCwvLCwsLCw0LCwsLS0sLDcsLCwsLP/AABEIANYA7AMBIgACEQEDEQH/xAAbAAEAAgMBAQAAAAAAAAAAAAAABAcCBQYDAf/EADkQAAEDAwICCAUDAgYDAAAAAPAAAQIDESFhcRKhBAUVMUFRU9EGExSRkyIywUKBI1JzseHxM0OC/8QAGwEBAAMBAQEBAAAAAAAAAAAAAAECAwQFBwb/xAAqEQEAAQMBCAEDBQAAAAAAAAAAAQIDEVEEEhQVITFSkUEicYEFE7HB8f/aAAwDAQACEQMRAD8AmoByRkXqPnIBjZAMbIgHJAAxsgGNkAxsgGNkBEA5IgAaoBqiAaoAGrIBqgGrIBqyAiAaogAc0AzugHNAOaABndAOaAZ3QDO6AiAc0QANEA0dEA3QANEA0QDR0A0dAREQAMbIBjZAOSAY2QAMbJYtdAMbJYtdAA0QDRANEA0QEQDR0QAMbIBjZEAxsgAY2QDGyAY2QDGyAiAY2RAA1QDVEA1QANUA1QDVANWQEQDVEADO6AZ3RAOaABndAOaAZ3QDO6AiAc0QANEA0dEA0QANHQDRANHQDR0BERAAxslizuiWLP8AwgIBoiAaIAGjoBogGjoBogIgGiIAHJAMbIgHJAAxsgHJAMbIBjZARAMbIByQEA1ZEQANUA1QDVANWQEQDVkQAM7oBndEAzugAZ3QDmgGd0AzugIgHNEADRANEQDRAA0dANEA0dANEBDx/hANEsZ/hARAM7oBzQEA0dEA0QANHQDdANHQDR0BEA0QDRAA5IBjZEAxsgAY2QDkgGNkAxsgAckQDGyAY2QANUA1RANUADVkA1QDVANUBEA1RAA5oBndEA5oAHNAOaAZ3QDO6AiAZ3QDmgIBo6IBogAaIf1fwgGiHj/CABzQDmgHNAM7oAHNEAzugHNAQDR0RAA0dANHQDRANHQEQDRANEADkgGNkQDkgAY2QDGyAY2QDGyAByRAMbIByQANUA1READVkA1ZANWQDVkBEA1RAA5oBndEA5oAGd0A5oBzQDO6ABzRAM7oBzQEuXf+ES5d2QGA+6Ac0QDmgAZ3QDO6AZ3QDmgAc0QDmgHNAA0QDREQANHQDRANHQDR0ADREA0dEADkgGNkQDkgAY2QDGyAY2QDGyAByRAMbIByQEA1READVANWRANWQANUQDVkQEA5ogHNAAzugGd0AzugHNAA5pcu7IBzS5eyAiAasgGqABzQDO6IBzQAM7oBndAOaAZ3QAOaIBzQDmgIBoiIAGjoBogGiAaOgIgGiIAHJAMbIiABjZAMbIBjZAMbIAGNkQDGyAckBANURAA1ZANUA1QDVkADVEA1ZEADO6Ac0QDmgAZ3S5eyAc0uXZAA1QDVANUA1QFtureoZVaXzak4UaXqVH78+DYxfxvstRLuAuy6P4w/b0Xh/wDD8lnhb9vFZrvvw8POyzrmcxEfLs2W3RNFdyuN6KMdO2c/1CP034feNF6tCtTr045k8Ha7N4va7s+ub6LXdH6LxUK1R5WajGD2te7zlws2h4qP4Pa9scVr2fN48Vu/Nra92V2vVWOhRj83oj8dSlTi7xuz2Zn+XL/PU8lWuqaI1dGzWLW03Ppp3YiOsZz1+Mdpcp1p0L5Nd6by4naMHd7Ws8434bfbdRDz/wC/53W8+MOkcXS3bipSaLyZvlt+pv2xeNV/GX6e5Y/CnRYy6Q9Sp/46EXqy8ct+3fud/wD5ZWiv6N6WV3ZYna5s2+2fX+IfW3VsqE4wnKLylCM3Zr3jxY4Zf3Z21t4YUWhRlOcYQa8pO0WbV8Le9fUKdejLplCU3/xGhVjUbLO/C0eH7wxr5sonwnbtKjfzn9/lTsfyoiv6M/MF3ZqY2qLcdKapjHXPSflLq/Cz2lGnXpVK0I8U6Mf3M1u5nve+7NfC55nv3B/wuk+Hr9tz8/m9J4tuKfK/DyWg6Tb5s7d3zJ2243tySiZzieqdrtWooiu3Tu/VMYznt8vIDR0A0dANEA0davPANEQDRANEADkgGNkRAAxsgGNkAxsgGNkADkiAY2QDGyAgGqIgAasgGqAaoBqgIgGrIBqgAc0uXb+US5dv5QEA1READVlt+revZU6PyqtOFele7Qn3x8cPZ8eNrbP4LUAaoBqq1UxV3a2b9dqreonDc9N6+4qMqVCjToQn+/htKUtL2a2+X8lH6L1q8I0Y8DO1GrKt+790nazXxi397rXAaoBqo3KcYaztl6at7PXt2j7sqk3lOUn75SlJ95SeT/7jqZ1R1nKhVeUWaTSbhnCXdKL6+f8AyoKK0xExhjRdror/AHKZxLa9Z9c/MotSpUoUaTPxPGL34peF3s2PHWzZxZeFTrLNB6VOFOdFm/XHLzlj9Uu7yfGb3fKggZ3QDmqxRENK9ru1TMzPfGnx2xp+HQ1Pin90qXR6dOtOPDKsz3fdo2bOG738Gvey56LYQDO6Ac1NNEU9kX9puXsb85x+PuIBoiKzAA0QDR0A0QDR0BEA0dANEBAMbIiABjZAMbIBjZAMbIAHJEAxsgGNkBANURAA1ZANWQDVANUADVLmP5QDVDw/lAA5Iqo7Tr+tW/LU907Tr+tW/LU91zcTGj3+QV+celroBqqo7Tr+tW/LU907Tr+tW/LU904mNDkFfnHpa4GqAasqqp9bV4yZ2rVbs7O16k3bHmzvZ2VidRdbR6RR4mxJsTj5S00fvb/taW7sVzhxbb+mXNmpiqZ3o/hsQNUXL/GHXvy4/Jou7VHb9cmfMY+TO3dJ+TZ8VyHadf1q35anuq134pnHdrsv6Pcv24uTO7nstdAOaqjtOv61b8tT3TtOv61b8tT3VeJjR0cgr849LXAzugGd1VHadf1q35anunadf1q35anunExocgr849LXA5oqo7Tr+tW/LU907Tr+tW/LU904mNDkFfnHpa6AaKqO06/rVvy1PdO06/rVvy1PdOJjQ5BX5x6WuBo6AaOqo7Tr+tW/LU907Tr+tW/LU904mNDkFfnHpa4GiKqO06/rVvy1PdO06/rVvy1PdOJjQ5BX5x6WugGNlVHadf1q35anunadf1q35anunExocgr849LXAxsgGNlVHadf1q35anunadf1q35anunExocgr849LXAxsiqjtOv61b8tT3TtOv61b8tT3TiY0OQV+celroBqqo7Tr+tW/LU907Tr+tW/LU904mNDkFfnHpa4GqHh/KqjtOv61b8tT3TtKt61b8tT3TiY0OQV+cekVERcj9OJJrd+O58+T5Z0a183t4277eNr+K3NTrxp9JpVZ0mj8rig0abyt8mztTptxO9njxSbia2OG1uFkGlupfVnT6lGo86L2dovxYu3D5ybR7ZW16J8QxjK86V2aLRhZ24oM0aLS4XZmvd6Ur/6ktb+lH4khGDs1H9zQZo3p8FPhi8Xek3B3u7tPOOJmuzqYnCtVNNUbtUZiXO1aryk8pPeUnd3d+93fvdYxy7M2Xfut47Ld9B63p06NNng9R4znKVOXB8qbPKLx+Zdnk7twvaz4d/K7SlT+JadpWoZd2fid24pYaz1MPd42vG93z3soWiMObljvxbD38/JZNSl4RfLM/c/c7szPs7uzf3W27Yj9TUqcEo/MZrNB4XhaTSeMLxtwOzcL3a9ny754sqvX7v0h6jRdmeEabRaTYjGvGrbu7rR4bW8UGkfvS631T4gaXR5wnSZ5zaoz1MXfjlJ4cTW7qbO3Dti2Fj0Hr1ocLTptJowhGNrNKDtCpGdSDtb9UnlHx/p7+52DRrKcHa3Eztdmk12drxfuk1+9tVt+mddxnTmzUKcZSeTtUa3E13dmazMzWak7wx4/q78L2pfEEWoNCdFpuzUo/qdnjJqdOjC02du7/Dk7YxxvrcNC3dfwuzX8LvezX/s/wBnXy63lfruMo8DtUeDx4ZvKUOOX6elNxfpi0bt9RG3+k2nD6t8Rw4ZRei3C8XjFrt4zrPaWLOztUps+P8A1Nju4Q55fVL616W1Ws84xeLO0Ws7t3tFmd7Nhm0bDeHk0RAREQEREBERAREQEREBERAREQEREBERAREQEREBERAREQEREBERAREQEREBERAREQEREBERAREQEREBERAREQEREBERAREQEREBERAREQERT6HU9WdKM6bNJpPZmvaWZvBv3WZ/1NazO75bGWQQEU/sWvn/AAnxe+Y+DX884y3nm3cjdS1+5oXe8ms0oO/6OC74fLXqQbHjjvQQEUx+q6ni0WfhlKzzg1mjUjTdne9mdpSZrO9+/wAUh1XVetGm8eGc3ZotLvzfPC15O2H7m/3ZBDRbCr1HXjKzw8Xbi4otF7SaLZd2td3ZmvZ3vhl4x6tqu9mhd2e1mlB34vGPCz3eTeMe+PizIIqKfPqas0GnwM8HjxcUZwePC0Xk73Z7Ws3e2PC98KAgk/Qy84/d/ZPoZecfu/siIH0MvOP3f2T6GXnH7v7IiB9DLzj939k+hl5x+7+yIgfQy84/d/ZPoZecfu/siIH0MvOP3f2T6GXnH7v7IiB9DLzj939k+hl5x+7+yIgfQy84/d/ZPoZecfu/siIH0MvOP3f2T6GXnH7v7IiB9DLzj939k+hl5x+7+yIgfQy84/d/ZPoZecfu/siIH0MvOP3f2XrTo1YuzxnZ4tZrO+GafGzNj/MzS3REHs1TpFnZqr2e7uzO9rva793k1tG7ljH57d1R+6Tfufuk7PLw8XjF92byXxEGbVOkcTS+a/E0eFnu/wC13u7d2csz75WFSNZ3Z3nlmizPd72jHhbOzv8Ad/NfEQZTlXf91R3zfMn7+Jp3d7Z/UzP/AGWT1Okeq+bf1PfD3Z72vfXvfxRECrUrya0qruz4td7Wta3d3W8O5RPoZecfu/siIP/Z",
            //        Price = 39
            //    },
            //    new Product
            //    {
            //        Id = 3,
            //        Title = "Honey",
            //        CategoryId = 3,
            //        ProductArtUrl =
            //            "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQInPhFeub-1BubIzUMamT3d7pMXCCV9uO8otU2uDZvBLSQE7UUOQ",
            //        Price = 29
            //    }


            //};
            //products.ForEach(s => context.Products.AddOrUpdate(s));
            //context.SaveChanges();

           
        }
    }
}
