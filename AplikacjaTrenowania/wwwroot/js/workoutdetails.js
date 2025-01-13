function workoutDetails(IdTreningu, button) {
    const rows = document.querySelectorAll(`tr.details${IdTreningu}`);
    rows.forEach(row => {
        if (row.classList.contains("hiddenDetails")) {
            row.classList.remove("hiddenDetails");
        } else {
            row.classList.add("hiddenDetails");
        }
    });
}