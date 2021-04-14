
class Osoba(var imie:String, var nazwisko:String){
    override fun toString() = "$imie $nazwisko"
}

fun main(args: Array<String>) {

    var osoby = listOf(
        Osoba("Bwa","Bdam"),
        Osoba("Bwa","Aowalski"),
        Osoba("Artur","Aowalski"),
        Osoba("Artur","Bdam")
    )

    // bez sorta
    println("..:: No sort ::..");
    osoby.forEach{ println(it) };
    println();

    // a)
    println("..:: a) sortedBy imie ::..");
    osoby.sortedBy{ it.imie }.forEach{ println(it) };
    println();

    // b)
    println("..:: b) sortedWith imie ::..");
    osoby.sortedWith { a, b ->
        a.imie.compareTo(b.imie);
    }.forEach{ println(it) };
    println();

    // c)
    println("..:: c) sortedWith nazwisko, imie ::..");
    osoby.sortedWith { a, b ->
        val r: Int = a.nazwisko.compareTo(b.nazwisko);
        if (r == 0) {
            a.imie.compareTo(b.imie);
        } else {
            r;
        }
    }.forEach{ println(it) };
    println();

    // d)
    println("..:: d) sortedBy nazwisko, imie ::..");
    osoby.sortedBy{ it.nazwisko + " " + it.imie }
        .forEach{ println(it) };
    println();
}
