export const getHtml = async (element) => {
    if (element) {
        return element.innerHTML;
    }
    return null;
}