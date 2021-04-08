import kotlin.math.sqrt

class Prostokat(var a: Double, var b: Double) {
    var obwod
        get() = 2 * this.a + 2 * this.b;
        set(obw: Double) {
            this.a = obw/4.0;
            this.b = this.a;
        }
    var pole
        get() = this.a * this.b;
        set(pol) {
            this.a = sqrt(a);
            this.b = this.a;
        }
    val przekatna
        get() = sqrt(this.a * this.a + this.b * this.b)

    override fun toString() = "a: ${this.a}\t b: ${this.b}\t Obwód: ${this.obwod}\t pole: ${this.pole}\t Przekątna: ${this.przekatna}";
}

fun main(args: Array<String>) {
    val prostokaty = listOf(
        Prostokat(2.0, 2.0),
        Prostokat(4.20, 6.9),
        Prostokat(2.5, 4.5),
        Prostokat(3.0, 1.0)
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
    println(prostokaty.sortedBy { it.a })
    println();
}