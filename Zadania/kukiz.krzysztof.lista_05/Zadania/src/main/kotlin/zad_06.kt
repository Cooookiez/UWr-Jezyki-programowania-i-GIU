class Rozkład(var n: Int = 1) {
    var i = 2
    operator fun iterator()=this
    operator fun hasNext()=n>1
    operator fun next():Int {
        while(n%i!=0) i++
        n/=i
        return i
    }
}

class Dzielniki(var n: Int = 1) {
    var i = 1
    operator fun iterator() = this
    operator fun hasNext() = 1 < n/2 && i < n/2
    operator fun next(): Int {
        do {i++} while (n % i != 0)
        return n/i
    }
}

fun main(){
    print("120=")
    for(x in Rozkład(120))
        print(" $x")
    println()
    for(x in Dzielniki(120))
        print(" $x")
}