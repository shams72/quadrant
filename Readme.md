# Quadrantensystem

## Aufbau der Quadranten

```
    |
  1 | 2
----|----
  4 | 3
    |
```

`currentQuadrant = 1, 2, 3 oder 4`

### Bei ungeraden Quadranten (1, 3):

- Um an der X-Achse zu spiegeln: `[(((currentQuadrant - 1) % 4) + 4) % 4]` + 1
- Um an der Y-Achse zu spiegeln: `[(currentQuadrant + 1) % 4]` + 1 
  
### Bei geraden Quadranten (2, 4):

- Um an der X-Achse zu spiegeln: `[(currentQuadrant + 1) % 4]` + 1
- Um an der Y-Achse zu spiegeln: `[(((currentQuadrant - 1) % 4) + 4) % 4]`+ 1



## Funktionsweise

Wenn eine Zahl gegeben ist, die weniger als vierstellig ist, wird sie auf der linken Seite mit Nullen aufgefüllt, bis sie vier Stellen erreicht. Danach wird, abhängig von der X- und Y-Achse, der Ziel-gespiegelte Quadrant berechnet. Das Wort wird dann an die Funktion übergeben, die es verarbeitet und die entsprechenden ASCII-Werte für den Quadranten zurückgibt. Diese erzeugten ASCII-Werte werden im Array gespeichert.

## Klassenstruktur: `Quadrant`

### Felder
- `private string[] quadrantValues = new string[4]`: Speichert die ASCII-Darstellung in jedem der vier Quadranten.
- `private int currentQuadrant = 0`: Gibt den aktuell aktiven Quadranten an (Index 0–3).
- `private string currentWord = ""`: Enthält das aktuell eingegebene Wort (Zahl).

### Öffentliche Methoden

#### `string GetCurrentWord()`
- **Rückgabewert:** Das aktuelle vierstellige Wort.
- **Zweck:** Gibt uns die eingegebene Zahl zurück.

#### `int GetCurrentQuadrant()`
- **Rückgabewert:** Der aktive Quadrant (1–4).
- **Zweck:** Gibt den aktuell gesetzten Quadranten zurück.

#### `bool SetValueInQuadrant(string value, string axis)`
- **Parameter:**
  - value: Die zu spiegelnde Zahl (als String).
  - axis: "X" oder "Y", .
- **Rückgabewert:** true, wenn erfolgreich gespiegelt wurde, sonst false.
- **Zweck:** Spiegelt den aktuellen Wert in einem anderen Quadranten.
- Spiegelung funktioniert nur, wenn der erste Quadrant initialisiert ist.

#### `bool SetQuadrant(int value)`
- **Parameter:**
  - value: Ziel Quadrant (1–4).
- **Rückgabewert:** true, wenn der Wechsel möglich ist.
- **Zweck:** Wechselt zu den gewünschten Quadranten.

#### `void SetValueInQuadrantONE(string firstQuadrantValue)`
- **Parameter:**
  - firstQuadrantValue: Eine Zahl zur Initialisierung von Quadrant 1.
- **Zweck:** Initialisiert den ersten Quadranten und speichert das Wort. Falls die Eingabe kürzer als 4 Zeichen ist, wird sie **links mit Nullen (0) aufgefüllt**, um eine vierstellige Darstellung zu gewährleisten.

#### `void PrintQuadrants()`
- **Zweck:** Gibt alle vier Quadranten mit ihren Werten und Spiegelungen aus.
- **Inhalte:** ASCII-Werte sowie Reflexionen über X- und Y-Achse.

### Private Methoden

#### `static string ReverseString(string input)`
- **Zweck:** Kehrt eine Zeichenkette um.
- **Verwendung:** Für Spiegelungen entlang der Y-Achsen.

#### `static string GenerateAsciiArt(string word, int axis)`
- **Parameter:**
  - word: Zeichenkette aus Ziffern (0–9).
  - axis: Quadrant-Index (0–3).
- **Rückgabewert:** Eine ASCII-Art-Darstellung der übergebenen Zeichenkette.
- **Zweck:** Erzeugt eine stilisierte ASCII-Darstellung je nach Quadrant.
