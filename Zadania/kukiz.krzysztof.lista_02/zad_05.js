
function BST(key, left=null, right=null) {
    this.key = key;
    this.left = left;
    this.right = right;

    return this;
}

BST.prototype.insert = function(key) {
    if (this.key == undefined || this.key == null) {
        this.key = key;
    } else {
        if (key < this.key) {
            if (this.left == undefined || this.left == null) {
                this.left = new BST(key);
            } else {
                this.left.insert(key);
            }
        } else {
            if (this.right == undefined || this.right == null) {
                this.right = new BST(key);
            } else {
                this.right.insert(key);
            }
        }
    }
}

BST.prototype[Symbol.iterator] = function *() {
    if (this.left) {
        // console.log(this.left);
        this.left;
    }
    // console.log(this.key);
    yield this.key;
    if (this.right) {
        // console.log(this.right);
        this.right;
    }
}


let b = new BST();

b.insert(8);
b.insert(10);
b.insert(3);
b.insert(6);
b.insert(4);
b.insert(1);
b.insert(7);
b.insert(14);
b.insert(13);

// console.log(b);
// b.ite()

for (let bb of b) {
    console.log(bb);
}
