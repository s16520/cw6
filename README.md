# cw6

1. Dodanie middleware - sprawdzanie indeksu
W tym zadaniu musimy dodac własny middleware. Pamietamy, ze dodawania middleware i
podpinaniu pod tzw. "pipelinezwiazany z przetwarzaniem zadan HTTP odbywa sie w klasie
Startup.cs i metodzie Configure.
Naszym zadaniem jest dodanie middleware’u, który sprawdzi czy wszystkie zadania przychodzace
do naszego API pochodza od studentów. Z tego powodu oczekujemy, ze kazde zadania
bedzie posiadało numer studenta w nagłówku zadania zapisanego pod kluczem "Index".
Ponadto nasz middleware powinien sprawdzic czy taki student faktycznie istnieje w bazie
danych. Ponizej mamy fragment kodu do uzupełnienia. Pamietaj, ze kolejnosc dodawanie
middleware do pipeline’a jest wazna. Uwierzytelnienie powinna zachodzic na poczatku.
W przypadku kiedy nagłówek Index nie znajduje sie w zadaniu - zwracamy bład 401.
app.Use(async (context, next) =>
{
//Custom code
await next();
});


2. Dodanie middleware - logowanie zadan do pliku
W tym wypadku chcielibysmy stworzyc dodatkowy middleware, który bedzie logowac podstawowe
informacje zwiazane ze wszystkimi przychodzacymi do nas zadaniami. Tym razem
stworzymy middleware w osobnej klasie. W tym celu warto dodac folder o nazwie Middlewares.
Nastepnie wewnatrz niego umiescic klase podobno do ponizszej. W metodzie
InvokeAsync umieszczamy nasz kod. Chcemy zapisywac do pliku o nazwie requestsLog.txt
nastepujace informacje:
Metode HTTP (GET, POST, itd.)
ciezke na która zostało wysłane zadanie (/api/students)
Dodanie logowania ciała zadania HTTP (np. wysłany JSON)
Zapisywanie informacji z Query string (?name=Kowalski)
public class LoggingMiddleware
{
private readonly RequestDelegate _next;
public LoggingMiddleware(RequestDelegate next)
{
_next = next;
}
public async Task InvokeAsync(HttpContext httpContext)
{
//Our code
await _next(httpContext);
}
}
Nastepnie w klasie Startup.cs dodajemy uruchomienie metody UseMiddleware. W celu zarejestrowania
middleware dodajemy w klasie Startup.cs -> COnfigure
app.UseMiddleware<LoggingMiddleware>();
