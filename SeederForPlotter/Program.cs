using SeederForPlotter.Implementations;
using SeederForPlotter.Interfaces;
using SeederForPlotter.Models;

namespace SeederForPlotter
{
    internal class Program
    {
        private static readonly ApplicationDBContext _db = new();
        static async Task Main()
        {
            Console.WriteLine("Seeder for Plotter");
            bool close = false;
            while(!close)
            {
                ShowOperations();
                var operation = ChooseOperation();
                if(operation == 0)
                    break;
                else if(operation == 1)
                {
                    ShowCategories();
                    close = await AddCertainData();
                }
                else if(operation == 2)
                {
                    ShowCategories();
                    close = await DeleteCertainData();
                }
                else if (operation == 3)
                {
                   await AddAllData();
                }
                else if (operation == 4)
                {
                   await DeleteAllData();
                }
            }
        }
        static void ShowOperations()
        {
            Console.WriteLine("\nКакую операцию выполнить:");
            Console.WriteLine("1) Добавление (по категориям)");
            Console.WriteLine("2) Удаление (по категориям)");
            Console.WriteLine("3) Полное добавление");
            Console.WriteLine("4) Полное удаление");
            Console.WriteLine("\n0) Для выхода");
            Console.WriteLine();
        }

        static void ShowCategories()
        {
            Console.WriteLine("\nКатегории:");
            Console.WriteLine("1) Жанры");
            Console.WriteLine("2) Модификаторы доступа");
            Console.WriteLine("3) Возрастной рейтинг");
            Console.WriteLine("4) Статусы произведения:");
            Console.WriteLine("5) Роли");
            Console.WriteLine("6) Мировоззрения");
            Console.WriteLine("\n0) Для выхода");
        }
        static int ChooseOperation()
        {
            switch (Console.ReadLine())
            {
                case "0":
                    return 0;
                case "1":
                    Console.WriteLine("Выбрано добавление (по категориям)");
                    return 1;
                case "2":
                    Console.WriteLine("Выбрано удаление (по категориям)");
                    return 2;
                case "3":
                    Console.WriteLine("Выбрано полное добавление");
                    return 3;
                case "4":
                    Console.WriteLine("Выбрано полное удаление");
                    return 4;
                default:
                    return -1;
            }
        } 
        static async Task<bool> AddCertainData()
        {
            switch (Console.ReadLine())
            {
                case "0":
                    return true;
                case "1":
                    IBaseRepository<Genre> genreRepository = new GenreRepository(_db);
                    await MakeSeedsFor(genreRepository);
                    Console.WriteLine("Добавление записей типа 'Жанр' выполнено!");
                    return false;
                case "2":
                    IBaseRepository<Access_Modificator> access_modificatorRepository = new Access_ModificatorRepository(_db);
                    await MakeSeedsFor(access_modificatorRepository);
                    Console.WriteLine("Добавление записей типа 'Модификтор доступа' выполнено!");
                    return false;
                case "3":
                    IBaseRepository<Rating> ratingRepository = new RatingRepository(_db);
                    await MakeSeedsFor(ratingRepository);
                    Console.WriteLine("Добавление записей типа 'Возрастной рейтинг' выполнено!");
                    return false;
                case "4":
                    IBaseRepository<Book_Status> book_statusRepository = new Book_StatusRepository(_db);
                    await MakeSeedsFor(book_statusRepository);
                    Console.WriteLine("Добавление записей типа 'Статус произведения' выполнено!");
                    return false;
                case "5":
                    IBaseRepository<Role> roleRepository = new RoleRepository(_db);
                    await MakeSeedsFor(roleRepository);
                    Console.WriteLine("Добавление записей типа 'Роль' выполнено!");
                    return false;
                case "6":
                    IBaseRepository<Worldview> worldViewRepository = new WorldviewRepository(_db);
                    await MakeSeedsFor(worldViewRepository);
                    Console.WriteLine("Добавление записей типа 'Мировоззрение' выполнено!");
                    return false;
                default:
                    Console.WriteLine("\nНичего не было выбрано");
                    return false;
            }
        }
        static async Task<bool> DeleteCertainData()
        {
            switch (Console.ReadLine())
            {
                case "0":
                    return true;
                case "1":
                    IBaseRepository<Genre> genreRepository = new GenreRepository(_db);
                    await DeleteSeedsFor(genreRepository);
                    Console.WriteLine("Удаление записей типа 'Жанр' выполнено!");
                    return false;
                case "2":
                    IBaseRepository<Access_Modificator> access_modificatorRepository = new Access_ModificatorRepository(_db);
                    await DeleteSeedsFor(access_modificatorRepository);
                    Console.WriteLine("Удаление записей типа 'Модификтор доступа' выполнено!");
                    return false;
                case "3":
                    IBaseRepository<Rating> ratingRepository = new RatingRepository(_db);
                    await DeleteSeedsFor(ratingRepository);
                    Console.WriteLine("Удаление записей типа 'Возрастной рейтинг' выполнено!");
                    return false;
                case "4":
                    IBaseRepository<Book_Status> book_statusRepository = new Book_StatusRepository(_db);
                    await DeleteSeedsFor(book_statusRepository);
                    Console.WriteLine("Удаление записей типа 'Статус произведения' выполнено!");
                    return false;
                case "5":
                    IBaseRepository<Role> roleRepository = new RoleRepository(_db);
                    await DeleteSeedsFor(roleRepository);
                    Console.WriteLine("Удаление записей типа 'Роль' выполнено!");
                    return false;
                case "6":
                    IBaseRepository<Worldview> worldViewRepository = new WorldviewRepository(_db);
                    await DeleteSeedsFor(worldViewRepository);
                    Console.WriteLine("Удаление записей типа 'Мировоззрение' выполнено!");
                    return false;
                default:
                    Console.WriteLine("\nНичего не было выбрано");
                    return false;
            }
        }
        static async Task AddAllData()
        {
            IBaseRepository<Genre> genreRepository = new GenreRepository(_db);
            IBaseRepository<Access_Modificator> access_modificatorRepository = new Access_ModificatorRepository(_db);
            IBaseRepository<Book_Status> book_statusRepository = new Book_StatusRepository(_db);
            IBaseRepository<Rating> ratingRepository = new RatingRepository(_db);
            IBaseRepository<Role> roleRepository = new RoleRepository(_db);
            IBaseRepository<Worldview> worldViewRepository = new WorldviewRepository(_db);
            try
            {
                await MakeSeedsFor(genreRepository);
                await MakeSeedsFor(access_modificatorRepository);
                await MakeSeedsFor(book_statusRepository);
                await MakeSeedsFor(ratingRepository);
                await MakeSeedsFor(roleRepository);
                await MakeSeedsFor(worldViewRepository);
                Console.WriteLine("Добавление всех записей прошло успешно!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[AddAllData] : {ex.Message}");
            }
        }
        static async Task DeleteAllData()
        {
            IBaseRepository<Genre> genreRepository = new GenreRepository(_db);
            IBaseRepository<Access_Modificator> access_modificatorRepository = new Access_ModificatorRepository(_db);
            IBaseRepository<Book_Status> book_statusRepository = new Book_StatusRepository(_db);
            IBaseRepository<Rating> ratingRepository = new RatingRepository(_db);
            IBaseRepository<Role> roleRepository = new RoleRepository(_db);
            IBaseRepository<Worldview> worldViewRepository = new WorldviewRepository(_db);
            try
            {
                await DeleteSeedsFor(genreRepository);
                await DeleteSeedsFor(access_modificatorRepository);
                await DeleteSeedsFor(book_statusRepository);
                await DeleteSeedsFor(ratingRepository);
                await DeleteSeedsFor(roleRepository);
                await DeleteSeedsFor(worldViewRepository);
                Console.WriteLine("Удаление всех записей прошло успешно!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DeleteAllData] : {ex.Message}");
            }
        }
        static async Task MakeSeedsFor<T>(IBaseRepository<T> repository)
        {
            try
            {
                await repository.Add();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static async Task DeleteSeedsFor<T>(IBaseRepository<T> repository)
        {
            try
            {
                await repository.Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}