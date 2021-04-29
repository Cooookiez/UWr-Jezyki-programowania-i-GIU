import kotlin.math.sqrt

import Prostokat

class Plakat(
    var tekst: String = "Witaj!",
    a: Double = 21.0,
    b: Double = 29.7,
    var kolor: String = "#FFF"
) : Prostokat(a, b) {

    override fun toString(): String = "’$tekst’ (plakat $a x $b w kolorze $kolor)"
}

fun main(args: Array<String>) {
    val prostokaty = listOf(
        Prostokat(2.0, 2.0),
        Prostokat(4.20, 6.9),
        Prostokat(2.5, 4.5),
        Prostokat(3.0, 1.0),
        Plakat(),
        Plakat("Hello word", kolor = "#777"),
        Plakat("inny wymiar, inny kolor", 4.0, 20.0, "#000"),
        Plakat("malo mi", 1.0, 0.5, "#FA8"),
    )

    println("..:: a) for ::..")
    for (prostokat in prostokaty) {
        println(prostokat)
    }
    println();

    println("..:: b) foreach ::..")
    prostokaty.forEach { println(it) }
    println();


    println("..:: sortedBy a ::..")
    prostokaty.sortedBy { it.a }.forEach {println(it) }
//    println(prostokaty.sortedBy { it.a })
    println();
}