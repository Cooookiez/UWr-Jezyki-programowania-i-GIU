
fun String.długość() = this.length

operator fun Int.times(text:String):String{
    var res="";
    repeat(this){res+=text};
    return res
}

operator fun String.times(n: Int): String {
    var res = ""
    for (i in this.chunked(1)) {
        repeat(n) {
            res += i
        }
    }
    return res
}

fun main() {
    println(3 * "Witaj! ")
    println("Ala ma kota" * 3)
}