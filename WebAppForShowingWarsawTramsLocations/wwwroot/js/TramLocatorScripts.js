function GenerateMap() {
    var divWithMap = $("#map");

    var warsawCenter = { lat: 52.230316, lng: 21.011181};
    var map = new google.maps.Map(
        document.getElementById('map'), { zoom: 12, center: warsawCenter });
    

    $.get("/api/GetTramsLocation", function (data, status) {
        if (status === 'success') {

            data.forEach(function (element) {
                let positionOfTram = { lat: element.lat, lng: element.lon };
                new google.maps.Marker({ position: positionOfTram, map: map, title: `Tramwaj linii: ${element.firstLine}` });
            });

            divWithMap.append("<br><br>");
            GenerateTable(data);
        }
    });
}

function GenerateTable(data) {
    var table = $("#TramLocationTable");

    table.append(
        "<tr><th>Status</th><th>FirstLine</th><th>Lines</th><th>LowFloor</th><th>Latitude</th><th>Longititude</th><th>Time</th><th>Brigade</th></tr>");

    data.forEach(function(element) {
        table.append(
            `<tr><td>${element.status}</td><td>${element.firstLine}</td><td>${element.lines}</td><td>${element.lowFloor
            }</td><td>${element.lat}</td><td>${element.lon}</td><td>${element.time}</td><td>${element.brigade
            }</td></tr>`);
    });
}