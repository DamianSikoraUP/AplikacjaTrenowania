document.getElementById('addSeria').addEventListener('click', function () {
    console.log('Dodaj serię');
    const serieContainer = document.getElementById('form-group-seria');
    const seria = document.createElement('div');
    seria.classList.add('row', 'mt-2');

    seria.innerHTML = `
                <div class="seryjka">
                    <input type="number" placeholder="Kg" class="form-control seria-kg" />
                </div>
                <div class="seryjka">
                    <input type="number" placeholder="Powtórzenia" class="form-control seria-powtorzenia" />
                </div>
                <div class="seryjka">
                    <button type="button" class="btn btn-danger remove-seria">Usuń</button>
                </div>
            `;
    serieContainer.appendChild(seria);

    // Dodaj obsługę usuwania serii
    seria.querySelector('.remove-seria').addEventListener('click', function () {
        seria.remove();
    });
});