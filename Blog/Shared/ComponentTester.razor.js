export const getHtml = async (element) => {
    console.log('getHtml');
    if (element) {
        return element.innerHTML;
    }
    return null;
}