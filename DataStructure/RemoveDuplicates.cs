// 有两个文件，文件里都是单词，在任何一个文件中去除另一个文件中存在的单词。

string result1 = File.ReadAllText(@"C:\Users\xu98826\Desktop\source.txt", Encoding.Default);
string result2 = File.ReadAllText(@"C:\Users\xu98826\Desktop\target.txt", Encoding.Default);
string result = result2.Replace(result1, "");
File.WriteAllText(@"C:\Users\xu98826\Desktop\target.sql", result);
Console.WriteLine(result);

//ReadAllLines,
public static void CopyFile(string source, string target) {
    //1、我们创建一个负责读取的流
    using(FileStream fsRead = new FileStream(source, FileMode.Open, FileAccess.Read)) {
        //2、创建一个负责写入的流
        using(FileStream fsWrite = new FileStream(target, FileMode.OpenOrCreate, FileAccess.Write)) {
            byte[] buffer = new byte[1024 * 1024 * 5];
            //因为文件可能会比较大，所以我们在读取的时候 应该通过一个循环去读取
            while (true) {
                //返回本次读取实际读取到的字节数
                int r = fsRead.Read(buffer, 0, buffer.Length);
                //如果返回一个0，也就意味什么都没有读取到，读取完了
                if (r == 0) {
                    break;
                }
                fsWrite.Write(buffer, 0, r);
            }
        }
    }
}

// 马大姐|4000
// 宋子文|8200
//
// 马大姐|8000
// 宋子文|16400
//1.读取
using(StreamReader reader = new StreamReader("工资文件.txt", Encoding.Default)) {
    //2.写入
    using(StreamWriter writer = new StreamWriter("新工资文件.txt", false, Encoding.UTF8)) {
        string line = null;
        while ((line = reader.ReadLine()) != null) {
            string[] parts = line.Split('|'); //string[] parts = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            string newLine = parts[0] + "|" + Convert.ToInt32(parts[1]) * 2;
            writer.WriteLine(newLine);
        }
    }
}
