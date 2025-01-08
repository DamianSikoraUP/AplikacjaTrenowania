function deleteWorkout(id, button) {
    console.log(id);
    const dane = {
        id: id
    };
    const url = "/Trening/Delete/${id}";
    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Requested-With': 'XMLHttpRequest'
        },
        body: id
    })
        .then(response => {
            if (response.ok) {
                const row = button.closest('tr');
                if (row) row.remove();
            }
        })
        .catch(error => console.error('Błąd w żądaniu:', error));
}