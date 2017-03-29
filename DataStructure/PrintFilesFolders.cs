const fs = require('fs');
const path = require('path');

// 获取当前有没有传入目标路径，如果没有默认当前js所在文件夹
var target = path.join(__dirname, process.argv[2] || './');

function load(target) {
    var dirInfos = fs.readdirSync(target); //列出文件夹中的文件和文件夹

    var dirs = [];
    var files = [];

    // 判断文件夹中每一个内容是文件还是文件夹，分别添加到数组中
    dirInfos.forEach(info => {
        var stat = fs.statSync(path.join(target, info));
        if (stat.isFile()) {
            files.push(info);
        } else {
            dirs.push(info);
        }
    });

    // 子文件夹递归
    dirs.forEach(dir => {
        console.log(`dirname: ${path.join(target, dir)}`);
        load(path.join(target, dir));
    });

    // 打印文件
    files.forEach(file => {
        console.log(`filename: ${file}`);
    });
}

load(target);



static List<string> DirSearch(string target)
{
    List<string> directories = new List<string>();
    List<string> files = Directory.GetFiles(target).ToList(); //files in current directory

    foreach(string d in Directory.GetDirectories(target))
    {
        directories.Add(d);
        files.AddRange(DirSearch(d));
    }
    // return files;  //get files
    // return directories;  //get directories

    List<string> both = new List<string>();
    both.AddRange(directories);
    both.AddRange(files);
    return both;  //return both
}

// better method:
Directory.GetDirectories(target, "*", SearchOption.AllDirectories).ToList();
Directory.GetFiles(target, "*", SearchOption.AllDirectories).ToList();
