document.querySelectorAll(".rozwijanie-przycisk").forEach(button => {
        button.addEventListener("click", function () {
            let nextRow = this.closest("tr").nextElementSibling;
            while (nextRow && !nextRow.classList.contains("rozwijanie-przycisk-wiersz")) {
                if (nextRow.classList.contains("hidden")) {
                    nextRow.classList.remove("hidden");
                    // nextRow.classList.add("visible");
                } else {
                    // nextRow.classList.remove("visible");
                    nextRow.classList.add("hidden");
                }
                nextRow = nextRow.nextElementSibling;
            }
            this.textContent = this.textContent === "+" ? "-" : "+";
        });
    });