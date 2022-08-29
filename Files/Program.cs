using Files;

Menu menu = new Menu();
menu.startApp();
//DirectoryInfo dir = new DirectoryInfo(@"G:\COpy2");
//DirectoryInfo _dir = new DirectoryInfo(@"G:\");
//if (dir.Exists)
//{
//    foreach (var item in _dir.GetDirectories())
//    {
//        if (item.FullName.ToLower() == dir.FullName.ToLower())
//            dir = new DirectoryInfo(item.FullName);
//    }
//    Console.WriteLine("YES\n" + dir.FullName);
//}
//string name = "*.txt";
//name = name.Substring(name.IndexOf('.') + 1, name.Length - name.IndexOf('.') - 1);
//Console.WriteLine(name);
//string oldName = @"*.txt";
//Console.WriteLine(oldName.Substring(oldName.LastIndexOf(@".") + 1));
//DirectoryInfo dir = new DirectoryInfo(menu._console.TestFileName(oldName.Substring(0, oldName.LastIndexOf(@"."))));
//Console.WriteLine(dir.FullName);