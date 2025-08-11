function sumAllNumbers() {
    var numbers = [];
    for (var _i = 0; _i < arguments.length; _i++) {
        numbers[_i] = arguments[_i];
    }
    var total = 0;
    for (var _a = 0, numbers_1 = numbers; _a < numbers_1.length; _a++) {
        var num = numbers_1[_a];
        total += num;
    }
    return total;
}
console.log(sumAllNumbers(1, 2, 3)); // Output: 6
console.log(sumAllNumbers(10, 20, 30, 40, 50)); // Output: 150
console.log(sumAllNumbers()); // Output: 0
