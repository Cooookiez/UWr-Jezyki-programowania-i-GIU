
interface Massive {
    val mass: Double
}

class Osoba4(
    var name: String,
    override val mass: Double
) : Massive {
    override fun toString(): String = "Masa: $mass\t[Osoba: $name]"
}

class Zwierze(
    var name: String,
    var species: String,
    override val mass: Double
) : Massive {
    override fun toString(): String = "Masa: $mass\t[$species: $name]"
}

class Bagaz(
    var type: String,
    override val mass: Double
) : Massive {
    override fun toString(): String = "Masa: $mass\t[Bagaż: $type]"
}

fun main() {
    var cargo = listOf(
        Osoba4("Ala", 50.0),
        Osoba4("Tomek", 90.5),
        Osoba4("Bartek", 80.0),
        Zwierze("Max", "Pies", 12.0),
        Zwierze("Lebur", "Kot", 1.0),
        Zwierze("Gadacz", "Papuga", 0.8),
        Bagaz("Plecak", 8.0),
        Bagaz("Walizka", 20.0)
    )

    println("..:: Elementy ::..")
    cargo.forEach { println(it) }
    println();

    // a)
    println("..:: a) Malejąco ::..")
    cargo.sortedByDescending { it.mass }.forEach {println(it) }
    println()

    // b)
    println("..:: b) Średnia ::..")
    // srednia foreach
    var cargoSum = 0.0
    var cargoAvg: Double
    cargo.forEach {
        cargoSum += it.mass
    }
    cargoAvg = cargoSum/cargo.size
    println("[foreach]\tłączna masa: $cargoSum\tśrednia masa: $cargoAvg")
    cargoSum = cargo.fold(0.0) { sum, element -> sum + element.mass}
    cargoAvg = cargoSum/cargo.size
    println("[fold]\t\tłączna masa: $cargoSum\tśrednia masa: $cargoAvg")
    println()

    // c)
    println("..:: c) Elementy o wadze powyżej avg ($cargoAvg) ::..")
    cargo.filter {it.mass > cargoAvg}.forEach { println(it) }
    println()
}
