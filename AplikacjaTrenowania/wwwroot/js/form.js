const select1 = document.querySelector("#rodzajTreningu");
const select2 = document.querySelector("#wybierzCwiczenie");
const options = select2.querySelectorAll("option");

select1.addEventListener("change", () => {

    options.forEach(option => {
        option.hidden = true;
        option.disabled = true;
    });

    const trening = select1.value;

    options.forEach(option => {
        if (option.dataset.cwiczenie === trening) {
            option.hidden = false;
            option.disabled = false;
        }
    });

    select2.selectedIndex = -1;
});