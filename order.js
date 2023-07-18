window.addEventListener("DOMContentLoaded", function (e) {

    let longitude = document.querySelector("#longitude");
    
    let latitude = document.querySelector("#latitude");

    //default values for error or location not ashared
    let location = {
        latitude: "unknown",
        longitude: "unknown"
    };

    window.navigator.geolocation.getCurrentPosition(
        function (position) {
            location = {
                latitude: position.coords.latitude,
                longitude: position.coords.longitude
            };
            longitude.value = JSON.stringify(location.longitude);
            latitude.value = JSON.stringify(location.latitude);
        },
        function (error) {
            longitude.value = JSON.stringify(location.longitude);
            latitude.value = JSON.stringify(location.latitude);
        });

    const order = localStorage.getItem("order");

    //making order info object(was stringified)
    const pieOrder = JSON.parse(order);

    if (order) {
        //for for displaying pie on order page
        //grabbing
        const pie = document.querySelector(".pie");
        const title = pie.querySelector(".title");
        const price = pie.querySelector(".price");
        const desc = pie.querySelector(".desc");
        //setting values
        title.innerText = pieOrder.title;
        price.innerText = pieOrder.price;
        desc.innerText = pieOrder.desc;
        const img = pie.querySelector("img");
        img.setAttribute("src", `images/${pieOrder.id}.png`);
        img.setAttribute("alt", pieOrder.title);
    }

    //getting form data
    const formEl = document.querySelector('.form');

    formEl.addEventListener('submit', event => {
        event.preventDefault();

        let priceDto = document.querySelector("#price");
        priceDto.value = pieOrder.price;

        let pieDto = document.querySelector("#pie");
        pieDto.value = pieOrder.title;

        let descriptionDto = document.querySelector("#description");
        descriptionDto.value = pieOrder.desc;

        let longitudeDto = document.querySelector("#longitude");
        longitudeDto.value = longitude.value;

        let latitudeDto = document.querySelector("#latitude");
        latitudeDto.value = latitude.value;

        const formData = new FormData(formEl);
        const data = new URLSearchParams(formData);

        fetch('https://localhost:7072/api/order', {
            method: 'POST',
            body: data
        }).then(res => res.json())
        .then(data => console.log(data))
        .catch(error => console.log(error));
    });
});