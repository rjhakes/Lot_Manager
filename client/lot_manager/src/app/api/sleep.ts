// eslint-disable-next-line no-undef
const sleep = (delay: number) => {
    return new Promise ((resolve) => {
        setTimeout(resolve, delay)
    })
}

export default sleep;