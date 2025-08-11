function sumAllNumbers(...numbers: number[]): number {
  let total = 0;
  for (const num of numbers) {
    total += num;
  }
  return total;
}

console.log(sumAllNumbers(1, 2, 3)); // Output: 6
console.log(sumAllNumbers(10, 20, 30, 40, 50)); // Output: 150
console.log(sumAllNumbers()); // Output: 0