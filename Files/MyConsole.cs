using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Files
{
    class MyConsole
    {
        DirectoryInfo _dir = new DirectoryInfo(@"C:\");
        public DirectoryInfo MyDirectory
        {
            get { return _dir; }
        }
        public string TestDirectoryName(string name)
        {
            DirectoryInfo dir = new DirectoryInfo(name);
            if (dir.Exists)
            {
                return name;
            }
            else
            {
                dir = new DirectoryInfo(_dir.FullName + name);
                if (dir.Exists)
                    return _dir.FullName + name;
                else
                {
                    dir = new DirectoryInfo(_dir.FullName + name.Substring(0, name.LastIndexOf(@"\")));
                    if (dir.Exists)
                        return _dir.FullName + name;
                }
            }
            return name;
        }
        public string TestFileName(string name)
        {
            FileInfo dir = new FileInfo(name);
            if (dir.Exists)
            {
                return name;
            }
            else
            {
                dir = new FileInfo(_dir.FullName + name);
                if (dir.Exists)
                    return _dir.FullName + name;
                else
                {
                    dir = new FileInfo(_dir.FullName + @"\" + name);
                    if (dir.Exists)
                        return _dir.FullName + @"\" + name;
                }
            }
            return TestDirectoryName(name);
        }
        public bool FileCopyTest(string name)
        {
            if (name.IndexOf(@"*") != -1)
            {
                return true;
            }
            return false;
        }
        public bool IsFile(string name)
        {
            FileInfo file = new FileInfo(TestFileName(name));
            if (file.Exists)
                return true;
            return false;
        }
        public bool Exists(string name)
        {
            DirectoryInfo dir = new DirectoryInfo(name.Substring(0, name.Length - 1));
            if (dir.Exists)
                return true;
            return false;
        }
        public void Cd(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(TestFileName(path));
            if (dir.Exists)
            {
                foreach (var item in _dir.GetDirectories())
                {
                    if (item.FullName.ToLower() == dir.FullName.ToLower())
                        dir = new DirectoryInfo(item.FullName);
                }
                _dir = dir;
            }
            else
            {
                Console.WriteLine("Не удалось найти указанный путь");
            }
        }
        public void Dir()
        {
            foreach (var dir in _dir.GetDirectories())
            {
                Console.WriteLine($"{dir.Name,-20}");
            }
            foreach (var file in _dir.GetFiles())
            {
                Console.WriteLine($"{file.Name,-20}");
            }
        }
        public void Back()
        {
            DirectoryInfo dir = new DirectoryInfo($"{_dir.Parent}");
            if (dir.Exists)
            {
                _dir = dir;
            }
        }
        public void Cls()
        {
            Console.Clear();
        }
        public void CopyDirectory(string name, string path, bool recursive)
        {
            var dir = new DirectoryInfo(name);
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");
            DirectoryInfo[] dirs = dir.GetDirectories();
            Directory.CreateDirectory(path);
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(path, file.Name);
                file.CopyTo(targetFilePath);
            }
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(path, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
        public void Copy(string name, string path)
        {
            if (IsFile(name) || FileCopyTest(name))
            {
                path = TestDirectoryName(path);
                if (name[name.Length - 1] != '*' && name[name.Length - 2] != '.' && name[name.Length - 3] != '*')
                {
                    name = TestFileName(name);
                    File.Copy(name, path + name.Substring(name.LastIndexOf(@"\")), true);
                }
                else
                {
                    name = TestFileName(name);
                    DirectoryInfo dir = new DirectoryInfo(name.Substring(0, name.Length - 4));
                    foreach (var file in dir.GetFiles())
                    {
                        name = TestFileName(file.FullName);
                        File.Copy(name, path + name.Substring(name.LastIndexOf(@"\")), true);
                    }
                }
            }
            else 
            {
                path = TestDirectoryName(path);
                name = TestFileName(name);
                DirectoryInfo dir = new DirectoryInfo(path);
                dir.Create();
                CopyDirectory(name, path, true);
            }
        }
        public void Del(string name)
        {
            if (IsFile(name))
                File.Delete(TestFileName(name));
            else
                Directory.Delete(TestDirectoryName(name), true);
        }
        public void Mkdir(string allPath)
        {
            allPath = TestDirectoryName(allPath);
            var path = allPath.Split(@"\", StringSplitOptions.RemoveEmptyEntries);
            path[0] = path[0] + @"\";
            for (int i = 1; i < path.Length; i++)
            {
                path[i] = path[i] + @"\";               
                path[i] = path[i - 1] + path[i];
                if (!Exists(path[i]))
                    Directory.CreateDirectory(path[i]);
            }
        }
        public void Move(string name, string path)
        {
            if (IsFile(name))
                File.Move(TestFileName(name), TestDirectoryName(path));
            else
                Directory.Move(TestDirectoryName(name), TestDirectoryName(path));
        }
        public string TestCreateFileFileName(string name)
        {
            FileInfo dir = new FileInfo(name);
            if (dir.Exists)
            {
                Console.WriteLine(dir.FullName);
                return name;
            }
            else
            {
                dir = new FileInfo(_dir.FullName + name);
                if (dir.Exists)
                    return _dir.FullName + name;
            }
            return name;
        }
        public void CreateFile(string fileName, string text)
        {
            if (!File.Exists(_dir.FullName + @"\" + fileName))
            {
                using (StreamWriter sw = File.CreateText(_dir.FullName + @"\" + fileName))
                {
                    sw.WriteLine(text);
                }
            }
        }
        public string ReadFile(string fileName)
        {
            if (IsFile(fileName))
            {
                using (StreamReader sr = File.OpenText(TestFileName(fileName)))
                {
                    string str = "";
                    while ((str = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(str);
                    }
                }
            }
            return "Неверное имя файла";
        }
        public void Attrib(string name)
        {
            FileInfo file = new FileInfo(TestFileName(name));
            Console.WriteLine($"Full name:  {file.FullName}\nCreation time:  {file.CreationTime}\nAttributes:  {file.Attributes}\nFile length:  {file.Length} bytes");
        }
        public void Ren(string oldName, string newName)
        {
            string fullName = null;
            if (oldName.IndexOf(@"\") != -1)
            {
                DirectoryInfo dir = new DirectoryInfo(oldName.Substring(0, oldName.LastIndexOf(@"\")));
                if (dir.Exists)
                {
                    oldName = oldName.Substring(oldName.IndexOf('.'), oldName.Length - oldName.IndexOf('.'));
                    newName = newName.Substring(newName.IndexOf('.'), newName.Length - newName.IndexOf('.'));
                    foreach (var file in dir.GetFiles())
                    {
                        if (file.Name.IndexOf('.') != -1)
                        {
                            if (file.Name.Substring(file.Name.IndexOf('.'), file.Name.Length - file.Name.IndexOf('.')) == oldName)
                            {
                                fullName = file.FullName;
                                File.Copy(file.FullName, file.DirectoryName + @"\" + file.Name.Substring(0, file.Name.IndexOf('.')) + newName);
                                File.Delete(fullName);
                            }
                        }
                    }
                }
            }
            else
            {
                oldName = oldName.Substring(oldName.IndexOf('.'), oldName.Length - oldName.IndexOf('.'));
                newName = newName.Substring(newName.IndexOf('.'), newName.Length - newName.IndexOf('.'));
                foreach (var file in _dir.GetFiles())
                {
                    if (file.Name.IndexOf('.') != -1)
                    {
                        if (file.Name.Substring(file.Name.IndexOf('.'), file.Name.Length - file.Name.IndexOf('.')) == oldName)
                        {
                            fullName = file.FullName;
                            File.Copy(file.FullName, file.DirectoryName + @"\" + file.Name.Substring(0, file.Name.IndexOf('.')) + newName);
                            File.Delete(fullName);
                        }
                    }
                }
            }
        }
        public void Where(string path, string type)
        {
            DirectoryInfo dir = new DirectoryInfo(TestFileName(path));
            foreach (var file in dir.GetFiles())
            {
                if (file.Name.Substring(file.Name.LastIndexOf(".")+1) == type.Substring(type.LastIndexOf(".") + 1))
                    Console.WriteLine($"{file.FullName}");
            }
        }
        public void Where(string path)
        {
            if (path.LastIndexOf(":") != -1 && path.Substring(path.LastIndexOf(":") + 1) == "*.*")
            {
                DirectoryInfo dir = new DirectoryInfo(TestFileName(path.Substring(0, path.LastIndexOf(@"\"))));
                foreach (var file in dir.GetFiles())
                {
                    Console.WriteLine($"{file.FullName}");
                }
            }
        }
    }
}
