function editWorkout(id, button) {
    const url = `/Trening/Edit?id=${id}`;
    fetch(url, {
        method: 'GET',
        headers: {
            'X-Requested-With': 'XMLHttpRequest'
        },
    })
        .then(response => {
            if (response.ok) {
                window.location.href = url;
            } else {
                console.error('Błąd w żądaniu:', response.status);
            }
        })
        .catch(error => console.error('Błąd w żądaniu:', error));
}