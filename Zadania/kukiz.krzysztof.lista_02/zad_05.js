
function BST(key, left, right) {
    this.key = key;
    this.left = left;
    this.right = right;
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

BST.prototype.ite = function () {
    if (this.left != undefined && this.left != null) {
        console.log(this.left.ite());
    } else {
        console.log(this.key);
    }
    if (this.right != undefined && this.right != null) {
        console.log(this.right.ite());
    } else {
        console.log(this.key);
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

console.log(b);

b.ite()