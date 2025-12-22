export function formatDateTime(dateStr){
    if (!dateStr) return "";

    const clean = dateStr.replace(/Z|([+-]\d\d:\d\d)$/g, "");
    const [date, time] = clean.split("T");

    if(!date || !time) return "";

    const [year, month, day] = date.split("-").map(Number);
    const [hour = "00", minute = "00"] = time.split(":");

     return     `${day.toString().padStart(2, "0")}.${
                month.toString().padStart(2, "0")
                }.${year}. ${hour.padStart(2, "0")}:${minute.padStart(2, "0")} h`;
}