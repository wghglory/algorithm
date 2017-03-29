Array.prototype.shuffle = function() {
    var input = this;
    for (var i = input.length - 1; i >= 0; i--) {
        var randomIndex = Math.floor(Math.random() * (i + 1));   // [0 - i]
        var itemAtIndex = input[randomIndex];
        input[randomIndex] = input[i];  //swap
        input[i] = itemAtIndex;
    }
    return input;
    // // 有些人说索引命中率不同
    // return input.sort(function(a, b) {
    //     return .5 - Math.random();
    // });
}
var tempArray = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
tempArray.shuffle();
console.log(tempArray);
