//1.找一个基准点 这里用中点
//2.建立两个数组，分别存储左边和右边的数组
//3.利用递归进行下次比较

function quickSort(arr) {
    if (arr.length <= 1) {
        return arr;
    }

    var num = Math.floor(arr.length / 2);

    var numValue = arr.splice(num, 1);

    var left = [];
    var right = [];

    for (var i = 0; i < arr.length; i++) {
        if (arr[i] < numValue) {  //any value less than pivot will be on left array
            left.push(arr[i]);
        } else {
            right.push(arr[i]);
        }
    }

    return quickSort(left).concat(numValue, quickSort(right));
}


console.log(quickSort([12, 5, 37, 6, 22, 40]));
