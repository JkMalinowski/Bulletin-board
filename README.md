# Bulletin-board
Opis:
Projekt zakłada stworzenie serwisu, w którym użytkownicy będą mogli wstawiać i przeglądać ogłoszenia.
Wymagania funkcjonalne:
1. Dodawanie ogłoszeń
Użytkownik powinien mieć możliwość dodania ogłoszenia, które zawiera tytuł oraz treść. Przed dodaniem ogłoszenia powinno wyświetlić się okno z pytaniem „Czy na pewno chcesz dodać ogłoszenie o następującym tytule: {tytuł ogłoszenia}”. Po dodaniu ogłoszenia powinien wyświetlić się komunikat o poprawnym wykonaniu akcji.
2. Główna strona serwisu
Na stronie głównej wyświetlane będą tytuły najnowszych ogłoszeń, których kliknięcie spowoduje wyświetlenie opisu ogłoszenia. Obok tytułu ogłoszenia powinna się wyświetlać data jego dodania. Wszystkie ogłoszenia będą posortowane według daty dodania do serwisu. Ogłoszenia powinny się wyświetlać maksymalnie przez 10 dni od daty dodania ich do serwisu.
Opcjonalnie ogłoszenia mogą być „page’owane” to znaczy wyświetlane w grupach po np. 100 tzn. na pierwszej stronie wyświetla się pierwsze 100 ogłoszeń, a następnie możemy przejść na kolejną drugą stronę by wyświetlić kolejne 100.
Wymagania niefunkcjonalne:
1. Wygląd
Projekt nie zakłada żadnego frameworka ani specjalnego szablonu wyglądu strony. Wyglądem nie należy się przejmować.
2. Baza danych
Projekt zakłada wykorzystanie frameworka Entity Framework Core w podejściu Code first z migracjami wykonywanymi podczas uruchomienia projektu.
3. Repozytorium
Kod serwisu powinien znajdować się w serwisie GitHub. Link do repozytorium należy przesłać w mailu.
4. Uruchomienie projektu
Należy sporządzić małą instrukcję dotyczącą uruchomienia projektu.
5. Technologia
Projekt należy utworzyć przy użyciu frameworka .NET 6. Mile widziane użycie ASP.NET Core MVC. Biblioteki JavaScriptowe nie są narzucone.
