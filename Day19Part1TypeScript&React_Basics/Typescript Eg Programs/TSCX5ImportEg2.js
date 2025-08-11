"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var EmployeeNew_1 = require("./EmployeeNew");
var employs = [
    new EmployeeNew_1.Employ(1, "Keshav", 88234),
    new EmployeeNew_1.Employ(2, "Rajesh", 88234),
    new EmployeeNew_1.Employ(3, "Arthy", 82245),
    new EmployeeNew_1.Employ(4, "Venkata", 88222)
];
employs.forEach(function (x) {
    console.log(x.empno + " " + x.name + " " + x.basic);
});
