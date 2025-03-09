const maxInputs = 8;
const minInputs = 3;

document.getElementById('addImageInput').addEventListener('click', function () {
    const imageInputs = document.getElementById('imageInputs');
    const currentInputCount = imageInputs.getElementsByTagName('input').length;

    if (currentInputCount < maxInputs) {
        const newInputDiv = document.createElement('div');
        newInputDiv.className = 'input-group mb-2';
        newInputDiv.innerHTML = `
                                        <label class="me-2">#${currentInputCount + 1} Image:</label>
                                        <input type="text" name="Images[${currentInputCount}]" class="form-control" placeholder="Image URL" />
                                    `;
        imageInputs.appendChild(newInputDiv);
        const hrElement = document.createElement('hr');
        imageInputs.appendChild(hrElement);
    } else {
        alert('Maximum of 8 images allowed.');
    }
});

// Ensure at least 3 inputs are present
window.addEventListener('load', function () {
    const imageInputs = document.getElementById('imageInputs');
    let currentInputCount = imageInputs.getElementsByTagName('input').length;

    while (currentInputCount < minInputs) {
        const newInputDiv = document.createElement('div');
        newInputDiv.className = 'input-group mb-2';
        newInputDiv.innerHTML = `
                                        <label class="me-2">#${currentInputCount + 1} Image:</label>
                                        <input type="text" name="Images[${currentInputCount}]" class="form-control" placeholder="Image URL" />
                                    `;
        imageInputs.appendChild(newInputDiv);
        const hrElement = document.createElement('hr');
        imageInputs.appendChild(hrElement);
        currentInputCount++;
    }
});