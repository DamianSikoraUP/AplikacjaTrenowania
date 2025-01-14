function deleteWorkout(id, button) {
    const url = `/Trening/Delete/${id}`;
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
//                const row = button.closest('tr');
//                if (row) row.remove();
                location.reload();
            }
        })
        .catch(error => console.error('Błąd w żądaniu:', error));
}