function mniejNizJedeeeeeeeen() {

    const rodzajTreningu = document.getElementById("rodzajTreningu").value;
    const wybierzCwiczenie = document.getElementById("wybierzCwiczenie").value;

    if (!rodzajTreningu) {
        alert("Pole z rodzajem treningu nie może być puste.");
        return false;
    }

    if (!wybierzCwiczenie) {
        alert("Pole z ćwiczeniem nie może być puste.");
        return false;
    }

    const przycisk = document.getElementById("addSeria");

    if (przycisk !== null) {
        const serie = document.querySelectorAll(".seria-row");
        if (serie.length === 0) {
            alert("Musisz dodać co najmniej jedną serię przed zapisaniem treningu.");
            return false;
        }

        const pola = document.querySelectorAll(".seria-kg, .seria-powtorzenia");
        for (const wartosc of pola) {
            if (wartosc.value < 1) {
                alert("Kilogramy oraz powtórzenia nie mogą być mniejsze od 1.");
                return false;
            }
        }
        return true;
    }
}