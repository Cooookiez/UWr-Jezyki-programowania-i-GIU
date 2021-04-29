
Array.prototype.wspak = function *() {
   for (let i = this.length-1; i >= 0; i--) {
    //    console.log(this[i]);
    yield this[i]
   }
}


// console.log([2, 3, 4].wspak());
for (let x of [2, 3, 4].wspak()) {
    console.log(x);
}