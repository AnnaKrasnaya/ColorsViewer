'use strict';

document.addEventListener('DOMContentLoaded', () => { 

    document.querySelector('#createBtn')
        .addEventListener("click", () => { getColors(false) });

    document.querySelector('#revertBtn')
        .addEventListener("click", () => { getColors(true) });

    function getColors(descendingOrder) {
        document.querySelector('#colorsDiv').innerHTML = '';
        let colorsNum = document.querySelector('#colorsNumber').value;
        if (colorsNum === undefined || colorsNum === null || colorsNum === '' || isNaN(parseInt(colorsNum))) {
            document.querySelector('#wrongNumberError').classList.remove('hidden');
        } else {
            document.querySelector('#wrongNumberError').classList.add('hidden');
            fetch(`${document.querySelector('#CreateUrl').value}?colorsNumber=${colorsNum}&descendingOrder=${descendingOrder}`)
                .then(response => response.text())
                .then(response => {
                    const parser = new DOMParser();
                    const html = parser.parseFromString(response, 'text/html')
                    const cnt = html.querySelector('.container');
                    document.querySelector('#colorsDiv').appendChild(cnt);
                }).catch(err => console.log(err));
        }       
    }
});
