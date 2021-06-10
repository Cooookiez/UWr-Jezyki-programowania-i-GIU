# Zad 01 - Wytyczne

## Panel sterujący

- [x] Kolor (u gury)
  - [x] R
  - [x] G
  - [x] B
- [x] Tryb zadawania koloru (pod kolorem)
- [x] zmiana kwadrat/kolo (też pod kolorem)

## Canvas

- [x] Koło lub kwadrat
- [x] Na dole napis: "__255, 255, 255 / #FFFFFF / 100%, 100%, 100%__"

## Dodatkowo co mylaślałem, że trzeba zrobić ale potem przeczytałem jeszce raz i o tym nic nie było, ale zostawiłem bo wygląda "fajniej"

- [x] Koło / kwadrat podąża za myszką

## Treść

Napisz program, który będzie wyświetlał pełne koło/kwadrat o kolorze sterowanym albo położeniem
kursora myszki, albo zawartością pól tekstowych, do których można wpisywać liczby. Tryb
zadawania koloru będzie wybierany przyciskiem, podobnie, jak kształt rysowanej figury.
 W tym celu umieść w środku okna aplikacji koło, a nad nim (w górnej części obszaru
roboczego) trzy pola tekstowe opisane za pomocą etykiet „Czerwony”, „Zielony” i „Niebieski”,
w które będzie można wpisać wartość rgb koloru, którym koło ma być namalowane. Poniżej tych pól
(ale powyżej koła) powinny znaleźć się dwa przyciski: „Kwadratura koła” oraz „Tryb”. Po
naciśnięciu pierwszego koło zmienia się w kwadrat o tym samym kolorze (i boku równym średnicy
koła), po powtórnym naciśnięciu kwadrat z powrotem staje się kołem. Każdorazowe naciśnięcie
drugiego przycisku przełącza tryb sterowania kolorem: z kursora myszy na pola tekstowe i odwrotnie.
W trybie myszy współrzędne x i y kursora myszy (w obszarze roboczym okna aplikacji) zadają
liczbowe wartości kolorów „r” i „g”, natomiast „b” jest zablokowane na poprzedniej wartości, zadanej
przez zawartość pola tekstowego „Niebieski”. Pamiętaj o ustawieniu początkowych wartości pól
tekstowych. Pod rysowaną figurą powinna znaleźć się informacja o bieżących wartościach
składowych koloru – „r”, „g” i „b”. Zadbaj także o odpowiedni tytuł okna.
