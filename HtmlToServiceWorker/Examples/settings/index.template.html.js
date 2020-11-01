// @ts-check
function settings() {
    async function getOptions() {
        const db = await DB.getReadOnlyDB(["settings"])
        const theme = await db.settings.get("theme")

        /**
         * @param {string|undefined} x
         */
        const selected = (x) => theme === x ? "selected" : ""

        return M.html`
            <option value=dark $${selected("dark")}>Dark Mode</option>
            <option value=light $${selected("light")}>Light Mode</option>
            <option value="" $${selected(void 0)}>Default</option>`
    }

    return { getOptions }
}

