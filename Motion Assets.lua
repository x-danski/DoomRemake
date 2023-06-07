//Built inside the LOVE.DRAW Framework, please download the assets before using this code via https://love2d.org/forums/viewtopic.php?t=10781

function love.load()
    -- Load a reference image to compare with the current frame
    referenceImage = love.graphics.newImage("reference.png")
    
    -- Set the initial state to idle
    state = "idle"
    
    -- Set the motion threshold (adjust this value according to your needs)
    motionThreshold = 50
    
    -- Set the motion detection area (in pixels)
    detectionArea = {
        x = 0,
        y = 0,
        width = love.graphics.getWidth(),
        height = love.graphics.getHeight()
    }
    
    -- Set the font for displaying text
    font = love.graphics.newFont(14)
    
    -- Initialize the motion counter
    motionCounter = 0
end

function love.update(dt)
    -- Capture the current frame
    local currentImage = love.graphics.newScreenshot()
    
    -- Compare the current frame with the reference image
    local diff = compareImages(referenceImage, currentImage)
    
    -- Calculate the average pixel difference
    local totalDiff = 0
    for i = 1, #diff do
        totalDiff = totalDiff + diff[i]
    end
    local averageDiff = totalDiff / (#diff * 3)
    
    -- Update the motion counter based on the average difference
    if averageDiff > motionThreshold then
        motionCounter = motionCounter + 1
    else
        motionCounter = math.max(motionCounter - 1, 0)
    end
    
    -- Change the state based on the motion counter
    if motionCounter > 0 then
        state = "motion detected"
    else
        state = "idle"
    end
end

function love.draw()
    -- Display the current state and motion counter
    love.graphics.setFont(font)
    love.graphics.print("State: " .. state, 10, 10)
    love.graphics.print("Motion Counter: " .. motionCounter, 10, 30)
end

function compareImages(image1, image2)
    local imageData1 = image1:getData()
    local imageData2 = image2:getData()
    
    local diff = {}
    
    for x = detectionArea.x, detectionArea.x + detectionArea.width - 1 do
        for y = detectionArea.y, detectionArea.y + detectionArea.height - 1 do
            local r1, g1, b1, _ = imageData1:getPixel(x, y)
            local r2, g2, b2, _ = imageData2:getPixel(x, y)
            
            local pixelDiff = math.abs(r1 - r2) + math.abs(g1 - g2) + math.abs(b1 - b2)
            table.insert(diff, pixelDiff)
        end
    end
    
    return diff
end
