// @ts-check
function defaultTemplate() {
    async function bodyClass() {
        const db = await DB.getReadOnlyDB(["settings"])
        return (await db.settings.get("theme")) || ""
    }

    return {
        "body-class": bodyClass
    }
}

