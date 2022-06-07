const slider = document.getElementById("myRange");
const output = document.getElementById("demo");
output.innerHTML = slider.value; 

slider.oninput = () => {
    output.innerHTML = slider.value;
    document.cookie = `value=${slider.value}`;
    document.getElementById("sliderInputValue").setAttribute("value", slider.value);
}