using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    internal class Menu
    {
        private MyConsole _console = new MyConsole();
        private string _choice = String.Empty;
        private bool _isExit = false;
        public bool SpaceTest(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    return true;
                }
            }
            return false;
        }
        public void ShowHelp()
        {
            Console.WriteLine($"cd - Смена текущей папки.\n" +
                $"dir - Вывод списка файлов и подпапок из указанной папки.\n" +
                $"cls - Очистка экрана.\n" +
                $"copy - Копирование одного или нескольких файлов в другое место.\n" +
                $"help - Выводит справочную информацию о командах.\n" +
                $"del - Удаление одного или нескольких файлов.\n" +
                $"mkdir - Создает каталог.\n" +
                $"md - Создает каталог.\n" +
                $"type - Вывод содержимого файла.\n" +
                $"attrib - Отображает атрибуты файлов.\n" +
                $"ren - Переименование одного или нескольких файлов.\n" +
                $"copy con - Создания текстового файла.\n" +
                $"move - Перемещения файлов.");
        }
        public void ShowHelpCd()
        {
            Console.WriteLine($"Смена текущей папки.\ncd [путь]\n" +
                $@"cd C:\ - Переход на диск С." + "\n" +
                $"cd.. - вернуться назад");
        }
        public void ShowHelpCopy()
        {
            Console.WriteLine($"Копирование одного или нескольких файлов в другое место.\n" +
                $"copy [имя копируемого объекта] [путь]\n" +
                $"copy [имя копируемого объекта]*.* [путь] - для копирование всех файлов\n" +
                $"copy con - Создание текстового файла.\n" +
                $"copy con [имя файла]\n" +
                $"Чтобы выйти из режима написания текста нажмите enter а затем F6.");
        }
        public void ShowHelpMkdir()
        {
            Console.WriteLine($"mkdir [диск:] путь\nНапример:\nmkdir C:\\A\\B\\C");
        }
        public void ShowHelpDir()
        {
            Console.WriteLine($"Вывод списка файлов и подкаталогов в указанном каталоге.");
        }
        public void ShowHelpCls()
        {
            Console.WriteLine($"Очищает содержимое экрана.");
        }
        public void ShowHelpDel()
        {
            Console.WriteLine($"Удаление одного или нескольких файлов.\n" +
                $"del [имя файла]");
        }
        public void ShowHelpMD()
        {
            Console.WriteLine($"md [диск:] путь\nНапример:\nmd C:\\A\\B\\C");
        }
        public void ShowHelpType()
        {
            Console.WriteLine("Вывод содержимого файла.\n" +
                "type [имя файла]");
        }
        public void ShowHelpAttrib()
        {
            Console.WriteLine($"attrib - Отображает атрибуты файлов.\n" +
                $"attrib [имя файла]");
        }
        public void ShowHelpRen()
        {
            Console.WriteLine($"Переименование одного или нескольких файлов.\n" +
                $"ren *.[старый тип] *.[новый тип]");
        }
        public void ShowHelpMove()
        {
            Console.WriteLine("Перемещения файлов.\n" +
                @"move [имя файла] [путь]\имя файла");
        }
        public void startApp()
        {
            while (!_isExit)
            {
                Console.Write($"{_console.MyDirectory.FullName}>");
                _choice = Console.ReadLine();
                string[] str = {""};
                if (SpaceTest(_choice))
                    str = _choice.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                switch (str[0])
                {
                    case "dir":
                        try
                        {
                            _console.Dir();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        break;
                    case "DIR":
                        try
                        {
                            _console.Dir();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        break;
                    case "cd":
                        try
                        {
                            _console.Cd(str[1]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "CD":
                        try
                        {
                            _console.Cd(str[1]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "cd..":
                        try
                        {
                            _console.Back();
                        }
                        catch (Exception ex)
                        {
                        }
                        break;
                    case "CD..":
                        try
                        {
                            _console.Back();
                        }
                        catch (Exception ex)
                        {
                        }
                        break;
                    case "cls":
                        _console.Cls();
                        break;
                    case "CLS":
                        _console.Cls();
                        break;
                    case "help":
                        if(str.Length < 2)
                            ShowHelp();
                        else if (str.Length < 3 || str.Length < 4 && str[2] == "con")
                            switch (str[1])
                            {
                                case "cd":
                                    ShowHelpCd();
                                    break;
                                case "move":
                                    ShowHelpMove();
                                    break;
                                case "copy":
                                    ShowHelpCopy();
                                    break;
                                case "dir":
                                    ShowHelpDir();
                                    break;
                                case "cls":
                                    ShowHelpCls();
                                    break;
                                case "del":
                                    ShowHelpDel();
                                    break;
                                case "mkdir":
                                    ShowHelpMkdir();
                                    break;
                                case "md":
                                    ShowHelpMD();
                                    break;
                                case "type":
                                    ShowHelpType();
                                    break;
                                case "ren":
                                    ShowHelpRen();
                                    break;
                                case "attrib":
                                    ShowHelpAttrib();
                                    break;
                                case "CD":
                                    ShowHelpCd();
                                    break;
                                case "MOVE":
                                    ShowHelpMove();
                                    break;
                                case "COPY":
                                    ShowHelpCopy();
                                    break;
                                case "DIR":
                                    ShowHelpDir();
                                    break;
                                case "CLS":
                                    ShowHelpCls();
                                    break;
                                case "DEL":
                                    ShowHelpDel();
                                    break;
                                case "MKDIR":
                                    ShowHelpMkdir();
                                    break;
                                case "MD":
                                    ShowHelpMD();
                                    break;
                                case "TYPE":
                                    ShowHelpType();
                                    break;
                                case "REN":
                                    ShowHelpRen();
                                    break;
                                case "ATTRIB":
                                    ShowHelpAttrib();
                                    break;
                                default:
                                    Console.WriteLine($"Команда '{str[1]}' не поддерживается.");
                                    break;
                            }
                        break;
                    case "HELP":
                        if (str.Length < 2)
                            ShowHelp();
                        else if (str.Length < 3)
                            switch (str[1])
                            {
                                case "cd":
                                    ShowHelpCd();
                                    break;
                                case "copy":
                                    ShowHelpCopy();
                                    break;
                                case "dir":
                                    ShowHelpDir();
                                    break;
                                case "cls":
                                    ShowHelpCls();
                                    break;
                                case "del":
                                    ShowHelpDel();
                                    break;
                                case "mkdir":
                                    ShowHelpMkdir();
                                    break;
                                case "md":
                                    ShowHelpMD();
                                    break;
                                case "type":
                                    ShowHelpType();
                                    break;
                                default:
                                    Console.WriteLine($"Команда '{str[1]}' не поддерживается.");
                                    break;
                            }
                        break;
                    case "copy":
                        try
                        {
                            if (str[1] == "con" && str.Length > 2)
                            {
                                string text1 = null;
                                string text2 = null;
                                do
                                {
                                    text1 = Console.ReadLine();
                                    text2 = text2 + text1 + "\n";
                                } while (Console.ReadKey().Key != ConsoleKey.F6);
                                _console.CreateFile(str[2], text2);
                            }
                            else
                            {
                                if (str[1] == "con")
                                    Console.WriteLine("Неверное имя файла");
                                else
                                    _console.Copy(str[1], str[2]);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "COPY":
                        try
                        {
                            if (str[1] == "con" && str.Length > 2)
                            {
                                string text1 = null;
                                string text2 = null;
                                do
                                {
                                    text1 = Console.ReadLine();
                                    text2 = text2 + text1 + "\n";
                                } while (Console.ReadKey().Key != ConsoleKey.F6);
                                _console.CreateFile(str[2], text2);
                            }
                            else
                            {
                                if (str[1] == "con")
                                    Console.WriteLine("Неверное имя файла");
                                else
                                    _console.Copy(str[1], str[2]);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "type":
                        try
                        {
                            _console.ReadFile(str[1]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "TYPE":
                        try
                        {
                            _console.ReadFile(str[1]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "del":
                        try
                        {
                            _console.Del(str[1]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "DEL":
                        try
                        {
                            _console.Del(str[1]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "mkdir":
                        try
                        {
                            _console.Mkdir(str[1]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "MKDIR":
                        try
                        {
                            _console.Mkdir(str[1]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "md":
                        try
                        {
                            _console.Mkdir(str[1]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "MD":
                        try
                        {
                            _console.Mkdir(str[1]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "move":
                        try
                        {
                            _console.Move(str[1], str[2]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "MOVE":
                        try
                        {
                            _console.Move(str[1], str[2]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "attrib":
                        try
                        {
                            _console.Attrib(str[1]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ошибка");
                        }
                        break;
                    case "ATTRIB":
                        try
                        {
                            _console.Attrib(str[1]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ошибка");
                        }
                        break;
                    case "ren":
                        try
                        {
                            _console.Ren(str[1], str[2]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "REN":
                        try
                        {
                            _console.Ren(str[1], str[2]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "where":
                        try
                        {
                            if (str.Length < 3)
                                _console.Where(str[1]);
                            else if (str.Length < 4)
                                _console.Where(str[1], str[2]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "WHERE":
                        try
                        {
                            if (str.Length < 3)
                                _console.Where(str[1]);
                            else if (str.Length < 4)
                                _console.Where(str[1], str[2]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "":
                        break;
                    default:
                        str = _choice.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        Console.WriteLine($"'{str[0]}' не является внутренней или внешней командой");
                        break;
                }
            }
        }
    }
}
