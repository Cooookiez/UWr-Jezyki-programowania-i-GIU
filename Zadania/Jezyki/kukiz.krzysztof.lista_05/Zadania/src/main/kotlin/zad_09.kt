
fun gcd(a: Int, b: Int): Int{
    var tmp: Int
    var x = a
    var y = b
    while (y != 0) {
        tmp = y
        y = x % y
        x = tmp
    }
    return x
}

data class Ułamek(var licznik:Int=0, var mianownik:Int=1){
    init{
        val x=gcd(Math.abs(licznik),mianownik)
        licznik/=x
        mianownik/=x
    }
    override fun toString()="$licznik/$mianownik"
    operator fun times(u:Ułamek)= Ułamek(this.licznik * u.licznik, this.mianownik * u.mianownik)
    operator fun div(u:Ułamek)= Ułamek(this.licznik * u.mianownik, this.mianownik * u.licznik)
    operator fun plus(u:Ułamek): Ułamek {
        val l1 = this.licznik * u.mianownik
        val l2 = u.licznik * this.mianownik
        val m = this.mianownik * u.mianownik
        return Ułamek(l1 + l2, m)
    }
    operator fun minus(u:Ułamek): Ułamek {
        val l1 = this.licznik * u.mianownik
        val l2 = u.licznik * this.mianownik
        val m = this.mianownik * u.mianownik
        return Ułamek(l1 - l2, m)
    }
    operator fun unaryMinus()= Ułamek(-1 * this.licznik, this.mianownik)
    operator fun unaryPlus()=this
    operator fun times(u:Int):Ułamek= Ułamek(u * this.licznik, this.mianownik)
    operator fun div(u:Int):Ułamek= Ułamek(this.licznik, u * this.mianownik)
    operator fun plus(u:Int):Ułamek= Ułamek(this.licznik  + (u * this.mianownik), this.mianownik)
    operator fun minus(u:Int):Ułamek= Ułamek(this.licznik  - (u * this.mianownik), this.mianownik)
}

operator fun Int.times(u:Ułamek):Ułamek= u * this
operator fun Int.plus(u:Ułamek):Ułamek= u + this
operator fun Int.minus(u:Ułamek):Ułamek= Ułamek(this, 1) - u
operator fun Int.div(u:Ułamek):Ułamek= Ułamek(this, 1) / u

fun main() {
    var a=Ułamek(2,5)
    var b=Ułamek(3,10)
    println("a=$a")
    println("b=$b")
    println("$a * $b = ${a*b}")
    println("$a / $b = ${a/b}")
    println("$a + $b = ${a+b}")
    println("$a - $b = ${a-b}")
    println("$a + 4 = ${a+4}")
    println("$a - 4 = ${a-4}")
    println("$a * 4 = ${a*4}")
    println("$a / 4 = ${a/4}")
    println("4 + $a = ${4+a}")
    println("4 - $a = ${4-a}")
    println("4 * $a = ${4*a}")
    println("4 / $a = ${4/a}")
}