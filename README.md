## Projekt z przedmiotu Wstęp do Logiki i Teorii Mnogości
### Program definiujący relacje zwrotne i symetryczne dla podanego n (max 5)
#### 0. Założenia początkowe
**Reprezentacja relacji**

Relacje binarne dla zbioru elementów o rozmiarze n są w programie reprezentowane za pomocą macierzy binarnej M o wymiarach n x n, gdzie każda kolumna oraz wiersz odpowiadają kolejno elementom a~1~, a~2~, ..., a~n~ ze zbioru, natomiast pola macierzy M[i,j] (gdzie i, j = 0,...,n-1) określają czy między uporządkowaną parą <a~i+1~,a~j+1~> zachodzi związek.

###### Przykład zapisu relacji

Przykładowa relacja zwrotna i symetryczna dla n = 4:

![picture](img/graphchart.jpg)

Reprezentacja relacji w programie:

| xRy  | a1 | a2 | a3 | a4 | 
| --- | --- | --- | --- | --- |
| a1  | 1  | 0  | 1  | 0  |
| a2  | 0  | 1  | 0  | 0  |
| a3  | 1  | 0  | 1  | 1  |
| a4  | 0  | 0  | 1  | 1  |

Pary uporządkowane:
<a1,a1>
<a2,a2>
<a3,a3>
<a4,a4>
<a3,a1>
<a1,a3>
<a4,a3>
<a3,a4>

**Własności relacji - zwrotność**
Jako relację zwrotną określamy taką relację, gdzie ![picture2](img/1.png)

