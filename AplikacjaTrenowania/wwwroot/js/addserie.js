//function mniejNizJedeeeeeeeen() {
//    const serie = document.querySelectorAll(".seria-row");
//    if (serie.length === 0) {
//        alert("Musisz dodać co najmniej jedną serię przed zapisaniem treningu.");
//        return false;
//    }

//    const pola = document.querySelectorAll(".seria-kg, .seria-powtorzenia");
//    for (const wartosc of pola) {
//        if (wartosc.value < 1) {
//            alert("Kilogramy oraz powtórzenia nie mogą być mniejsze od 1.");
//            return false;
//        }
//    }
//    return true;
//}

document.getElementById("addSeria").addEventListener("click", function () {
    const container = document.getElementById("form-group-seria");
    const rows = container.getElementsByClassName("seria-row");
    const index = rows.length;
    console.log(index);

    const seria = document.createElement("div");
    seria.className = "row seria-row";
    seria.innerHTML = `
        <div class="seryjka">
            <input type="number" name="Serie[${index}].Kg" placeholder="Kg" class="form-control seria-kg" min="1"/>
        </div>
        <div class="seryjka">
            <input type="number" name="Serie[${index}].Powtorzenia" placeholder="Powtórzenia" class="form-control seria-powtorzenia" min="1"/>
        </div>
        <div class="seryjka">
            <button type="button" class="btn btn-danger remove-seria">Usuń</button>
        </div>
        `;
    container.appendChild(seria);

    seria.querySelector(".remove-seria").addEventListener("click", function () {
        seria.remove();
    });
});



